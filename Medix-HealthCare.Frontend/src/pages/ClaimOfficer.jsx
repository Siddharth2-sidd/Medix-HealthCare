import React,{useState,useEffect} from 'react';
import api from "../services/api.js";

function ClaimOfficer(){
    const [claim, setClaim] = useState([]);

    useEffect(()=>{
        api.get("/ClaimOfficer/pendingClaim")
        .then(res => setClaim(res.data))
    },[]);

    const approve = (id,claimAmount)=>{
        api.post(`ClaimOfficer/Approve/${id}`,{
            decision:"Approved",
            approvedAmount:claimAmount,
            RejectionReason:""
        })
        .then(()=> alert("Approved"));
    }
    return (
        <div>
            <h2>Officer Dashboard</h2>
            {claim.map(c=>(
                <div key={c.id}>
                    {c.claimNumber} -   {c.claimAmount}
                    <button onClick={()=>approve(c.id,c.claimAmount)}>Submit</button>
                </div>
            ))}
        </div>
    )
}

export default ClaimOfficer;