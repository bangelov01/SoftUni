import React, { useState } from "react";

function BookCounter(props) {
    const [count, setCount] = useState(0);
    const [counterName, setCounterName] = useState("Current")

    function updateCounterName(newName) {
        setCounterName(oldState => oldState = newName)
    };

    function decrementCount() {
        setCount((oldState) => {

            if (oldState <= 0) {
                return oldState;
            }

            return oldState - 1;
        })
    }

    return(
        <div className="counter">
            <h3>Book Counter {counterName}!</h3>
            <button onClick={(e) => {decrementCount(); updateCounterName("Removed")}}>-</button>
            <span>{count}</span>
            <button onClick={(e) => {setCount((oldState) => oldState + 1); updateCounterName("Added")}}>+</button>
        </div>
    );
}

export default BookCounter;