import React,{useState} from 'react';
import api from "../services/api.js";
import {useNavigate} from "react-router-dom";

function Login(){
    const [email, setEmail]= useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const  handleChanges = async()=>{
        try{
            const response = await api.post('/auth/login',{email,password});
            localStorage.getItem("token",response.data.token);
            localStarage.getItem("role",response.data.role);

            if(response.data.token === "Admin")
                navigate("/admin");
            else if(response.data.token === "Pharmacy")
                navigate("/pharmacy");
            else if(response.data.token === "ClaimOfficer")
                navigate("/claimOfficer");
            else if(response.data.token === "finance")
                navigate("/finance");
        }catch(err){alert(err)}
    };

    return (
    <div>
        <h2>Medix-HealthCare Login</h2>
        <input type="email" placeholder="Add email here..." onChange={e=>setEmail(e.target.value)}/>
        <input type="password" placeholder = "Add password here..." onChange={e=>setPassword(e.target.value)}/>
        <button onClick={handleChanges}>Submit</button>
    </div>)
}

export default Login;