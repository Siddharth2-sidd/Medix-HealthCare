import React,{useState} from 'react';
import api from "../services/api.js";

function ClaimOfficer(){
    const [claim, setClaim] = useState([]);

    useEfffect(()=>{
        api.get("/ClaimOfficer/pendingClaim")
        .then(res => setClaim(res.data))
    },[]);

    const approve = (id)=>{
        api.post(`ClaimOfficer/Approve/${id}`,{
            decision:"Approved"
        })
        .then(()=> alert("Approved"));
    }
    return (
        <div>
            <h2>Officer Dashboard</h2>
            {claim.map(c=>(
                <div key={c.id}>
                    {c.claimNumber}-{c.claimAmount}
                    <button onClick={approve}>Submit</button>
                </div>
            ))}
        </div>
    )
}

export default ClaimOfficer;