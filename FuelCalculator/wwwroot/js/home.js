"use strict"

// Получение всех элементов заданной формы
const getFormById = (id) => {
    return {
        origin: document.getElementById("origins" + id).value,
        destination: document.getElementById("destination" + id).value,
        fuelType: document.getElementById("fuelType" + id).value,
        fuelConsumption: document.getElementById("fuelConsumption" + id).value
    };
}

// Выолнение запрос к бэку
const getFuelWeight = (id) => {
    let form = getFormById(id);
    $.ajax({
        url: '/FuelCalculator/GetFuelWeight',
        data: {
            origin: form.origin,
            destination: form.destination,
            fuelType: form.fuelType,
            fuelConsumption: form.fuelConsumption,
        }
    }).then((response) => {
        showSuccessBadge(id);
        setFormResult(id, response);
    })
        .catch((e) => {
            console.log(e);
            showFailBadge(id);
        });
}

const setFormResult = (id, result) => {
    $("#result" + id).val(result);
}

const showSuccessBadge = (id) => {
    $("#successForm" + id)[0].style.display = "block";
    setTimeout(() => {
        $("#successForm" + id)[0].style.display = "none";
    }, 2000);
}

const showFailBadge = (id) => {
    $("#failForm" + id)[0].style.display = "block";
    setTimeout(() => {
        $("#failForm" + id)[0].style.display = "none";
    }, 2000);
}


$("#updateButton")
    .click(function (e) {
        e.preventDefault();
        for(let i = 1; i <= 4; i++) {
            getFuelWeight(i);
        }
    });
