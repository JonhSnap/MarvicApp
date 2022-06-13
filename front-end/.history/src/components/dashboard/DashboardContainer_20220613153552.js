import React, { useEffect, useRef, useState } from "react";
import "./Dashboard.scss";
import BarChartArea from "../chart/BarChartArea";
import BarChartColumn from "../chart/BarChartColumn";
import BarChartDoughnut from "../chart/BarChartDoughnut";
import { timeLines } from "../../util/constants";

function DashboardContainer({ project }) {
  let ref = useRef(null);
  const dateStartedProject = new Date(project?.dateStarted);
  const dateEndProject = new Date(project?.dateEnd);
  const [timeLine, setTimeLine] = useState('project');
  const [chart, setChart] = useState("area");
  const [period, setPeriod] = useState({
    dateStart: `${dateStartedProject.getFullYear()}-${String(dateStartedProject.getMonth() + 1).padStart(2, '0')}-${String(dateStartedProject.getDate()).padStart(2, '0')}`,
    dateEnd: `${dateEndProject.getFullYear()}-${String(dateEndProject.getMonth() + 1).padStart(2, '0')}-${String(dateEndProject.getDate()).padStart(2, '0')}`
  });
  // handle change period
  const handleChangePeriod = (e) => {
    setPeriod(prev => {
      return {
        ...prev,
        [e.target.name]: e.target.value
      }
    })
  }

  const handleExportChart = () => {
    ref.current.chart.exportChart({ format: "png" })

  }
  return (
    <div className="container-dashboard">
      <h2 className="title">Dashboard</h2>
      <div className="mt-1 chart-container">
        {chart === "area" && <BarChartArea ref={ref} period={period} timeLine={timeLine} project={project} />}
        {chart === "column" && <BarChartColumn period={period} timeLine={timeLine} project={project} />}
        {chart === "doughnut" && <BarChartDoughnut period={period} timeLine={timeLine} project={project} />}
        <button onClick={handleExportChart} className="p-2 mt-3 text-white bg-blue-500 rounded-md hover:opacity-90">Export Chart</button>
        <div className="flex items-center gap-x-2">
          <select
            onChange={(e) => setChart(e.target.value)}
            value={chart}
            className="p-2 mt-3 border-2 border-blue-400 rounded-md cursor-pointer outline-blue-600"
          >
            <option value="area">Area Chart</option>
            <option value="column">Column Chart</option>
            <option value="doughnut">Doughnut Chart</option>
          </select>
          <select
            value={timeLine}
            onChange={e => setTimeLine(e.target.value)}
            className="p-2 mt-3 capitalize border-2 border-blue-400 rounded-md cursor-pointer outline-blue-600">
            {
              timeLines.map(item => (
                <option key={item} className="capitalize" value={item}>{item}</option>
              ))
            }
          </select>
          {
            timeLine === 'custom' &&
            <div className="flex p-1 ml-5 transition-all border-l-2 shadow-2xl animate__animated animate__backInLeft gap-x-2 ">
              <div className="flex flex-col gap-y-1">
                <label>Date start:</label>
                <input
                  value={period.dateStart}
                  onChange={handleChangePeriod}
                  name='dateStart'
                  type="date"
                  className="px-2 py-1 border-2 rounded outline-none cursor-pointer border-primary"
                />
              </div>
              <div className="flex flex-col gap-y-1">
                <label>Date end:</label>
                <input
                  value={period.dateEnd}
                  onChange={handleChangePeriod}
                  name='dateEnd'
                  type="date"
                  className="px-2 py-1 border-2 rounded outline-none cursor-pointer border-primary"
                />
              </div>

            </div>
          }
        </div>
      </div>
    </div>
  );
}

export default DashboardContainer;
