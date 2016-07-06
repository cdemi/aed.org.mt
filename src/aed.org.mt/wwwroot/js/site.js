function distance(lat1, lon1, lat2, lon2) {
    var p = 0.017453292519943295;    // Math.PI / 180
    var c = Math.cos;
    var a = 0.5 - c((lat2 - lat1) * p) / 2 +
            c(lat1 * p) * c(lat2 * p) *
            (1 - c((lon2 - lon1) * p)) / 2;

    return 12742 * Math.asin(Math.sqrt(a)); // 2 * R; R = 6371 km
}

function metersBetween2Cordinates(lat1, lon1, lat2, lon2) {
    var pos1 = new google.maps.LatLng(lat1, lon1);
    var pos2 = new google.maps.LatLng(lat2, lon2);
    return google.maps.geometry.spherical.computeDistanceBetween(pos1, pos2);
}

function humanReadableDistance(meters) {
    if (meters < 1000)
        return Math.round(meters) + " m";
    else {
        return (meters / 1000).toFixed(1) + " km";
    }
}