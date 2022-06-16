import React, { useEffect, useRef, useState } from "react";
import "./Dashboard.scss";
import BarChartArea from "../chart/BarChartArea";
import BarChartColumn from "../chart/BarChartColumn";
import BarChartDoughnut from "../chart/BarChartDoughnut";
import { useSelector } from "react-redux";

function DashboardContainer({project}) {

  const [chart, setChart] = useState("area");
  return (
    <div className="container-dashboard">
      <h2 className="title">Dashboard</h2>
      <div className="chart-container">
        {chart === "area" && <BarChartArea  project={project}  />}
        {chart === "column" && <BarChartColumn project={project} />}
        {chart === "doughnut" && <BarChartDoughnut project={project} />}

        {/* <BarChartColumn />
        <BarChartDoughnut /> */}

        <select
          onChange={(e) => setChart(e.target.value)}
          value={chart}
          className="p-2 mt-3 border-2 border-blue-400 rounded-md cursor-pointer outline-blue-600"
        >
          <option value="area">Area Chart</option>
          <option value="column">Column Chart</option>
          <option value="doughnut">Doughnut Chart</option>
        </select>
      </div>
    </div>
  );
}

export default DashboardContainer;
