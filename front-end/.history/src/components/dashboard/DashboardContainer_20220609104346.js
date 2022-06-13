import React, { useState } from "react";
import "./Dashboard.scss";
import BarChartArea from "../chart/BarChartArea";
import BarChartColumn from "../chart/BarChartColumn";
import BarChartDoughnut from "../chart/BarChartDoughnut";
import { useSelector } from "react-redux";

function DashboardContainer() {
  const { projects } = useSelector(state => state.projects);

  const [chart, setChart] = useState("area");
  return (
    <div className="container-dashboard">
      <h2 className="title">Dashboard</h2>
      <div className="chart-container">
        {chart === "area" && <BarChartArea />}
        {chart === "column" && <BarChartColumn />}
        {chart === "doughnut" && <BarChartDoughnut />}

        {/* <BarChartColumn />
        <BarChartDoughnut /> */}

        <select
          onChange={(e) => setChart(e.target.value)}
          value={chart}
          name=""
          id=""
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
