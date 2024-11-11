function toggleSearch() {
    const searchField = document.getElementById("search-field");
    searchField.classList.toggle("active");

    if (searchField.classList.contains("active")) {
        searchField.focus();
    }
}
