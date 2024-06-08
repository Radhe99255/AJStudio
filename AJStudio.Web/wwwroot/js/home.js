// Get the navigation links
const navLinks = document.getElementById('nav-links');
const menuBtn = document.getElementById('menu-btn');

// Add event listener to the menu button
menuBtn.addEventListener('click', () => {
    // Toggle the navigation links
    navLinks.classList.toggle('nav__links--active');
    // Toggle the menu button icon
    menuBtn.classList.toggle('open');
});

// Add event listener to the dropdown button
navLinks.addEventListener('click', (e) => {
    // Check if the target is a dropdown button
    if (e.target.classList.contains('dropbtn')) {
        // Toggle the dropdown content
        e.target.nextElementSibling.classList.toggle('dropdown-content--active');
    }
});