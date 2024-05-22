'use strict';

/**
* navbar toggle
*/

const overlay = document.querySelector("[data-overlay]");
const navbar = document.querySelector("[data-navbar]");
const navToggleBtn = document.querySelector("[data-nav-toggle-btn]");
const navbarLinks = document.querySelectorAll("[data-nav-link]");

const navToggleFunc = function () {
    navToggleBtn.classList.toggle("active");
    navbar.classList.toggle("active");
    overlay.classList.toggle("active");
}

navToggleBtn.addEventListener("click", navToggleFunc);
overlay.addEventListener("click", navToggleFunc);

for (let i = 0; i < navbarLinks.length; i++) {
    navbarLinks[i].addEventListener("click", navToggleFunc);
}


/**
* header active on scroll
*/

const header = document.querySelector("[data-header]");

window.addEventListener("scroll", function () {
    window.scrollY >= 10 ? header.classList.add("active")
        : header.classList.remove("active");
});

function validateForm() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    if (username == "" || password == "") {
        alert("Username and Password must be filled out");
        return false;
    }
}
document.getElementById('car-model').addEventListener('change', function () {
    var selectedCarId = this.value;

    fetch('/Book/GetCarDetails?carId=' + selectedCarId)
        .then(response => response.json())
        .then(car => {
            // Display the car card
            document.getElementById('car-card-section').style.display = 'flex';
            document.getElementById('car-card-section').innerHTML = `
                <div class="container">
                    <ul class="car-card-list">
                        <li>
                            <div class="new-car-card">
                                <figure class="card-banner">
                                    <img src="/images/${car.imageUrl}" alt="${car.model}" loading="lazy" width="440" height="300" class="w-100">
                                </figure>
                                <div class="card-content">
                                    <div class="card-title-wrapper">
                                        <h3 class="h3 card-title">
                                            <a href="#">${car.model}</a>
                                        </h3>
                                        <data class="year" value="${car.makeYear}">${car.makeYear}</data>
                                    </div>
                                    <ul class="card-list">
                                        <li class="card-list-item">
                                            <ion-icon name="people-outline"></ion-icon>
                                            <span class="card-item-text">${car.seaters} People</span>
                                        </li>
                                        <li class="card-list-item">
                                            <ion-icon name="flash-outline"></ion-icon>
                                            <span class="card-item-text">${car.fuelType}</span>
                                        </li>
                                        <li class="card-list-item">
                                            <ion-icon name="speedometer-outline"></ion-icon>
                                            <span class="card-item-text">${car.mileage}km / 1-litre</span>
                                        </li>
                                        <li class="card-list-item">
                                            <ion-icon name="hardware-chip-outline"></ion-icon>
                                            <span class="card-item-text">${car.transmission}</span>
                                        </li>
                                    </ul>
                                    <div class="card-price-wrapper">
                                        <p class="card-price">
                                            <strong>₹${car.rentPerDay}</strong> / day
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            `;
        });
});

var carData = {};

window.onload = function () {
    fetch('/Book/GetAllCars')
        .then(response => response.json())
        .then(data => {
            carData = data;
        });
};

function calculateTotalPrice() {
    var carModel = document.getElementById('car-model').value;
    var startDate = new Date(document.getElementById('start-date').value);
    var endDate = new Date(document.getElementById('end-date').value);

    //if (startDate > endDate) {
    //    alert('Start date cannot be after end date');
    //    return;
    //}

    if (carModel && startDate && endDate) {
        var rentPerDay = carData[carModel - 1].rentPerDay;

        var timeDifference = Math.abs(endDate.getTime() - startDate.getTime());
        var dayDifference = Math.ceil(timeDifference / (1000 * 3600 * 24));

        var totalPrice = dayDifference * rentPerDay;

        document.getElementById('total-price').value = totalPrice;
    }
}