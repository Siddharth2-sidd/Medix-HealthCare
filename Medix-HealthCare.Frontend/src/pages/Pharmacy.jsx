import React,{ useState } from "react";
import api from "../services/api.js";

function Pharmacy() {

  const [rawData, setRawData] = useState("");

  const submitClaim = async () => {
    try {

      await api.post(
        "/Pharmacy_/submit",{
        rawData:rawData 
    });

      alert("Claim Submitted");

    } catch (error) {
      console.error(error);
      alert("Error submitting claim");
    }
  };

  return (
    <div>

      <h2>Pharmacy Dashboard</h2>

      <textarea
        rows="10"
        cols="50"
        placeholder="Paste NCPDP data"
        onChange={(e) => setRawData(e.target.value)}
      />

      <br/>

      <button onClick={submitClaim}>
        Submit Claim
      </button>

    </div>
  );
}

export default Pharmacy;