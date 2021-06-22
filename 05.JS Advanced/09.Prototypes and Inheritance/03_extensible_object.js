function extensibleObject() {

    let obj = {
        extend: function(template) {
            for (const parentProto of Object.keys(template)) {
                if (typeof(template[parentProto]) == `function`) {
                    Object.getPrototypeOf(obj)[parentProto] = template[parentProto];
                }
                else{
                    obj[parentProto] = template[parentProto
                    ]
                }
            }
        }
    } 

    return obj;
}