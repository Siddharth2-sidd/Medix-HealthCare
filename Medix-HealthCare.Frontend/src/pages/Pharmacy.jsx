import React,{useState} from 'react';
import api from "../services/api.js";

function Pharmacy(){
    const [rawData, setrawData] = useState("");

    const submitClaim = async()=>{
        api.post("/api/Pharmacy_/submit",rawData,{
            header:{"Content-Type":"text/plain"}
        });
        alert("Claim Submitted");
    }

    return(
    <div>
        <h2>Pharmacy Dhashboard</h2>
        <textarea rows="10" cols="50" placeholder="paste raw data here" onChange={e=> setrawData(e.target.value)} />
        <br/>
        <button onClick={submitClaim}>Submit</button>
    </div>)
}
export default Pharmacy;