function sort(array) {
    let result = array.map(x => String(x)).sort(comparator);

    function comparator(a,b){
        if (a.length < b.length) {
            return -1;
        }
        else if (a.length > b.length) {
            return 1;
        }
        else{
            if (a.toLowerCase() < b.toLowerCase()) {
                return -1;
            }
            else if (a.toLowerCase() > b.toLowerCase()) {
                return 1;
            }
            else{
                return 0;
            }
        }
    }

    for (const item of result) {
        console.log(item);
    }

}

sort(['test', 
'Deny', 
'omen', 
'Default']
);
