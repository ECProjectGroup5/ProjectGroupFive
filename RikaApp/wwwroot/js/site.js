// cookie helper functions
function setCookie(name, value, days) {
    const expires = new Date(Date.now() + days * 864e5).toUTCString();
    document.cookie = `${name}=${encodeURIComponent(value)}; expires=${expires}; path=/`;
}

function getCookie(name) {
    return document.cookie.split('; ').reduce((r, v) => {
        const [key, val] = v.split('=');
        return key === name ? decodeURIComponent(val) : r;
    }, '');
}

// quantity selector
let quantity = parseInt(getCookie("quantity")) || 1;
const pricePerUnit = parseFloat(document.querySelector(".price").getAttribute("data-price"));

function increaseQuantity() {
    quantity++;
    updateQuantity();
    updateTotalPrice();
    setCookie("quantity", quantity, 7);
}

function decreaseQuantity() {
    if (quantity > 1) {
        quantity--;
        updateQuantity();
        updateTotalPrice();
        setCookie("quantity", quantity, 7);
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
    totalPriceElement.classList.add("price-update");
    totalPriceElement.textContent = `$${totalPrice.toFixed(2)}`;
    setTimeout(() => totalPriceElement.classList.remove("price-update"), 150);
}

// initialize quantity and total price
document.addEventListener("DOMContentLoaded", () => {
    updateQuantity();
    updateTotalPrice();
});

// star rating
const stars = document.querySelectorAll('.star');
const ratingValueDisplay = document.getElementById('ratingValue');
let selectedRating = parseInt(getCookie("rating")) || 0;

stars.forEach((star) => {
    star.addEventListener('click', () => {
        selectedRating = star.getAttribute('data-value');
        ratingValueDisplay.textContent = selectedRating;
        updateStarColors(selectedRating);
        setCookie("rating", selectedRating, 7);
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
        star.classList.toggle('selected', star.getAttribute('data-value') <= rating);
    });
}

// initialize star rating
document.addEventListener("DOMContentLoaded", () => {
    if (selectedRating) {
        ratingValueDisplay.textContent = selectedRating;
        updateStarColors(selectedRating);
    }
});

// favorite button
function toggleFavorite(button) {
    button.classList.toggle("active");
    setCookie("favorite", button.classList.contains("active"), 7);
}

// initialize favorite button state
document.addEventListener("DOMContentLoaded", () => {
    const favoriteButton = document.querySelector(".favoriteButton");
    if (getCookie("favorite") === "true") {
        favoriteButton.classList.add("active");
    }
});
