function calculateGcd(a,b) {
    
    while (b != 0) {
        let holder = b;
        b = a % b;
        a = holder;
    }

    return a;
}