//quantity selector
let quantity = 1;

const pricePerUnit = parseFloat(document.querySelector(".price").getAttribute("data-price"));

function increaseQuantity() {
    quantity++;
    updateQuantity();
    updateTotalPrice();
}

function decreaseQuantity() {
    if (quantity > 1) {
        quantity--;
        updateQuantity();
        updateTotalPrice();
    }
}

function updateQuantity() {
    const quantityInput = document.getElementById("quantity");
    quantityInput.value = quantity;
    document.querySelector(".decrement").disabled = quantity <= 1;
}

function updateTotalPrice() {
    const totalPriceElement = document.querySelector(".price");
    const totalPrice = pricePerUnit * quantity;
    totalPriceElement.textContent = `$${totalPrice.toFixed(2)}`;
}



// starsrating
const stars = document.querySelectorAll('.star');
const ratingValueDisplay = document.getElementById('ratingValue');
let selectedRating = 0;

stars.forEach((star) => {
    star.addEventListener('click', () => {
        selectedRating = star.getAttribute('data-value');
        ratingValueDisplay.textContent = selectedRating;
        updateStarColors(selectedRating);
    });

    star.addEventListener('mouseover', () => {
        updateStarColors(star.getAttribute('data-value'));
    });

    star.addEventListener('mouseleave', () => {
        updateStarColors(selectedRating);
    });
});

function updateStarColors(rating) {
    stars.forEach((star) => {
        if (star.getAttribute('data-value') <= rating) {
            star.classList.add('selected');
        } else {
            star.classList.remove('selected');
        }
    });
}

//favoritknappen
function toggleFavorite(button) {
    button.classList.toggle("active");
}

// Funktion för att gå tillbaka till föregående sida
function goBack() {
    window.history.back();
}

// Sökfunktion
function toggleSearch() {
    const searchField = document.getElementById("search-field");
    searchField.classList.toggle("active");

    if (searchField.classList.contains("active")) {
        searchField.focus();
    }
}