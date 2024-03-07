const list = document.querySelector(".list");
const detailsView = document.querySelector(".details-view");
const headerRef = document.querySelector("#header-content");

const listItem = document.querySelector(".list-item");

for (let i = 2; i < 10; i++) {
  let newListItem = listItem.cloneNode(true);
  newListItem.childNodes[1].src = `https://i.pravatar.cc/100?img=${i}`;
  newListItem.childNodes[3].innerHTML = `
  <p>User ${i}</p>
  <p>Message Content ${i}</p>`;
  list.appendChild(newListItem);
}

const storeCardInfo = {
  img: null,
  sender: "John Smith",
  subject: "Summer BBQ Party",
  reciepients: ["Alex, Mars"],
  body: "Lorem ipsum dolor sit amet."
};

let bounds = {};
let scaleX, scaleY;
let selectedCard;

list.addEventListener("click", ({ target }) => {
  selectedCard = target.closest(".list-item");
  bounds = selectedCard.getBoundingClientRect();
  scaleX = bounds.width / window.innerWidth;
  scaleY = bounds.height / window.innerHeight;
  console.log("Values while expanding: ", bounds, scaleX, scaleY);
  storeCardInfo.img = selectedCard.childNodes[1].src;
  let senderImage = document.querySelector("#sender-image");
  let messageDetails = document.querySelector("#message-details");
  senderImage.src = selectedCard.childNodes[1].src;
  messageDetails.innerHTML = selectedCard.childNodes[3].innerHTML;
  headerRef.innerHTML = "Back";
  // Similarly get data for sender name, subject
  detailsView.classList.add("opened");

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

headerRef.addEventListener("click", ({ target }) => {
  console.log("clicked header");
  if (headerRef.innerHTML === "Back") {
    detailsView.classList.remove("opened");
    headerRef.innerHTML = "Inbox";
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
