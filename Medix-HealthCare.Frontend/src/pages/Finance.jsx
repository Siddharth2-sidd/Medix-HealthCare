import {useState,useEffect} from 'react';
import api from "../services/api.js";

function Finance(){
    const[claim, setClaim] = useState([]);

    useEffect(()=>{
        api.get("/Finance/ApprovedClaim")
        .then(res => setClaim(res.data));
    },[])

    const pay = (id)=>{
        api.post(`/Finance/pay/${id}`)
        .then(()=>alert("Payment Successfull"));
    }
    return(
        <div>
            {claim.map(c=>(
                <div key={c.id}>
                    {c.claimNumber}
                    <button onClick={()=>pay(c.id)}>Submit</button>
                </div>))}
        </div>
    )
}
export default Finance;