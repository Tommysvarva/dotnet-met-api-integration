let params = {
    method: "GET",
    body: {
        latitude: 0,
        longitude: 0
    }
};

function GetWeatherForecast() {
    const url = "https://localhost:44388/api/v1/weatherforecast"
    console.log(params);
}

function GetGeoLocation() {
    if (navigator.geolocation) {
       navigator.geolocation.getCurrentPosition(GeoLocationSuccess, GeoLocationError);
    }
}

function GeoLocationSuccess(position) {
    params.body.latitude = position.coords.latitude
    params.body.longitude = position.coords.longitude
}

function GeoLocationError(error) {
    return error;
}
