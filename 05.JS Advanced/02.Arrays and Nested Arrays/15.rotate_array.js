function rotate(array, times) {
    
    for (let i = 0; i < times; i++) {
       
        let holder = array[array.length - 1];

        for (let j = array.length - 1; j >= 0; j--) {
            
        array[j] = array[j - 1];
                
        }      
        array[0] = holder;
    }
    console.log(array.join(` `));
}

rotate(['1', 
'2', 
'3', 
'4'], 
2)