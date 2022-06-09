import React from "react";
import "./Dashboard.scss";
import BarChartArea from "../chart/BarChartArea";
import BarChartColumn from "../chart/BarChartColumn";
import BarChartDoughnut from "../chart/BarChartDoughnut";

export const options = {
  responsive: true,
  maintainAspectRatio: true,
  width: "500px",
  plugins: {
    legend: {
      position: "top",
    },
    title: {
      display: true,
      text: "Chart.js Bar Chart",
    },
  },
};

const labels = ["January", "February", "March", "April", "May"];

export const data = {
  labels,
  datasets: [
    {
      label: "Dataset 1",
      data: [4, 6, 2, 7, 9],
      backgroundColor: "rgba(255, 99, 132, 0.5)",
    },
  ],
};

function DashboardContainer() {
  return (
    <div className="container-dashboard">
      <h2 className="title">Dashboard</h2>
      <div className="chart-container">
        {/* <BarChartArea />
        <BarChartColumn /> */}
        <BarChartDoughnut />
      </div>
    </div>
  );
}

export default DashboardContainer;
