import {BrowserRouter, Routes, Route} from "react-router-dom";
import Login from "./pages/Login.jsx";
import Admin from "./pages/Admin.jsx";
import Pharmacy from "./pages/Pharmacy.jsx";
import ClaimOfficer from "./pages/ClaimOfficer.jsx";
import Finance from "./pages/Finance.jsx";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login/>}/>
        <Route path="/admin" element={<Admin/>}/>
        <Route path="/pharmacy" element={<Pharmacy/>} />
        <Route path="/claimOfficer" element={<ClaimOfficer/>} />
        <Route path="/finance" element={<Finance/>} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
