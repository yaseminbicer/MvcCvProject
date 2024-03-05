function validateNumber(input) {
    if (input.value.length > 0) {
        // ilk girdi sıfır olamaz
        if (parseInt(input.value) === 0) {
            input.value = '';
        }
        // eğer girdi 100den büyükse, inputu 100'e ayarla
        else if (parseInt(input.value) > 100) {
            input.value = 100;
        }
    }
}
