import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import ClassCompFetchAll from "./ClassComponents/ClassCompFetchAll";
import PersonCRUD from "./Components/PersonCRUD";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <div>
    <ClassCompFetchAll />
    <PersonCRUD />
  </div>
);
