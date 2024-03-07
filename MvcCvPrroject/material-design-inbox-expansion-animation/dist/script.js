const listItems = document.querySelectorAll(".list-item");

listItems.forEach(item => {
    item.addEventListener("click", () => {
        const sender = item.dataset.sender;
        const subject = item.dataset.subject;

        document.querySelector(".detail-heading").textContent = subject;
        document.querySelector("#sender-image").src = item.querySelector("img").src;
        const messageDetails = document.querySelector("#message-details");
        messageDetails.innerHTML = `
                    <p>${item.querySelector(".list-item-body p:first-child").textContent}</p>
                    <p>${item.querySelector(".list-item-body p:last-child").textContent}</p>
                `;

        document.querySelector("#header-content").innerHTML = "Back";

        const detailsView = document.querySelector(".details-view");
        detailsView.classList.add("opened");

        const bounds = item.getBoundingClientRect();
        const scaleX = bounds.width / window.innerWidth;
        const scaleY = bounds.height / window.innerHeight;

        detailsView.animate(
            [
                {
                    transform: `translate(${bounds.left}px, ${bounds.top}px) scale(${scaleX}, ${scaleY})`
                },
                {
                    transform: `translate(0, 0) scale(1,1)`
                }
            ],
            {
                duration: 300,
                fill: "forwards",
                easing: "cubic-bezier(0.4, 0, 0.2, 1)"
            }
        );
    });
});

document.querySelector("#header-content").addEventListener("click", ({ target }) => {
    console.log("clicked header");
    if (target.innerHTML === "Back") {
        const detailsView = document.querySelector(".details-view");
        detailsView.classList.remove("opened");

        const bounds = selectedCard.getBoundingClientRect();
        const scaleX = bounds.width / window.innerWidth;
        const scaleY = bounds.height / window.innerHeight;

        document.querySelector("#header-content").innerHTML = "Inbox";

        detailsView.animate(
            [
                {
                    transform: `translate(0, 0) scale(1,1)`
                },
                {
                    transform: `translate(${bounds.left}px, ${bounds.top}px) scale(${scaleX}, ${scaleY})`
                }
            ],
            {
                duration: 300,
                fill: "backwards",
                easing: "cubic-bezier(0.4, 0, 0.2, 1)"
            }
        );
    }
});