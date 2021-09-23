function GetWeatherForecast() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(GeoLocationSuccess, (error) => console.log(error));
    };
};

async function GeoLocationSuccess(position) {
    const params = `?latitude=${position.coords.latitude}&longitude=${position.coords.longitude}`;
    await fetch('https://localhost:44388/api/v1/weatherforecast/locationforecast/complete' + params)
        .then(response => {
            console.log(response)
        })
        .catch(error => console.log(error))
};

