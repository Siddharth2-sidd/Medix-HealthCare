import React,{useState, useEffect} from 'react';
import api from "../services/api.js";
function Admin(){
    const[policy, setPolicy] = useState([]);

    useEffect(()=>{
        api.get("/Admin/policy")
        .then(res=>setPolicy(res.data))
        .catch(err => console.log(err))
    },[]);

    return (
        <div>
            <h2>Admin Dashboard</h2>
            <ul>
            {policy.map(p=>(
                <li key={p.id}>
                    {p.PolicyNumber}-{p.CoverageAmount}
                </li>
            ))}
            </ul>
        </div>
    )
}
export default Admin;