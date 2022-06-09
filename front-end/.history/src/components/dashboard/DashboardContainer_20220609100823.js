import React from "react";
import "./Dashboard.scss";

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
        <div className="chart-options">
          <div>chart 1</div>
          <div>chart 2</div>
          <div>chart 3</div>
        </div>
      </div>
    </div>
  );
}

export default DashboardContainer;
