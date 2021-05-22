function calculateTime(steps, footprintLengthMeters, speedInKm) {
    
    let distanceMeters = steps * footprintLengthMeters;
    let speedMetersSec = speedInKm / 3.6;

    let time = distanceMeters/speedMetersSec;
    let rest = Math.floor(distanceMeters/500);

    let timeMin = Math.floor(time/60);
    let timeSec = Math.round(time - (timeMin * 60));
    let timeHr = Math.floor(time / 3600);

    console.log((timeHr < 10 ? "0" : "") + timeHr + ":" + (timeMin + rest < 10 ? "0" : "") + (timeMin + rest) + ":" + (timeSec < 10 ? "0" : "") + timeSec);

}