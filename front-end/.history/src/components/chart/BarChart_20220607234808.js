import React, { useEffect, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
const BarChart = () => {
  var datapoints = [];
  const [datapoint, setDatapoint] = useState([]);
  const options = {
    theme: "light2",
    animationEnabled: true,
    exportEnabled: true,
    title: {
      text: "Number of iPhones Sold",
    },
    axisY: {
      title: "Number of iPhones ( in Million )",
    },
    data: [
      {
        type: "area",
        xValueFormatString: "YYYY",
        yValueFormatString: "#,##0.## Million",
        dataPoints: [
          { x: new Date(2017, 0), y: 7.6 },
          { x: new Date(2016, 0), y: 7.3 },
          { x: new Date(2015, 0), y: 6.4 },
          { x: new Date(2014, 0), y: 5.3 },
          { x: new Date(2013, 0), y: 4.5 },
          { x: new Date(2012, 0), y: 3.8 },
          { x: new Date(2011, 0), y: 3.2 },
        ],
      },
    ],
  };

  const optionsColumn = {
    title: {
      text: "Basic Column Chart",
    },
    data: [
      {
        // Change type to "doughnut", "line", "splineArea", etc.
        type: "column",
        dataPoints: [
          { label: "Apple", y: 10 },
          { label: "Orange", y: 15 },
          { label: "Banana", y: 25 },
          { label: "Mango", y: 30 },
          { label: "Grape", y: 28 },
        ],
      },
    ],
  };

  const dataP = async () => {
    await axios
      .get("https://canvasjs.com/data/gallery/react/nifty-stock-price.json")
      .then((res) => {
        setDatapoint(res.data);
      });
  };
  useEffect(() => {
    dataP();
  }, [datapoint]);
  console.log(datapoint);

  if (datapoint.length > 0) {
    const dataPoints = [];
    for (var i = 0; i < datapoint.length; i++) {
      dataPoints.push({
        x: new Date(datapoint[i].x),
        y: datapoint[i].y,
      });
    }
  }
  console.log(dataPoints);

  const optionsYMD = {
    theme: "light2",
    title: {
      text: "Comparison of Exchange Rates - 2017",
    },
    subtitles: [
      {
        text: "GBP & USD to INR",
      },
    ],
    axisY: {
      prefix: "₹",
    },
    toolTip: {
      shared: true,
    },
    data: [
      {
        type: "area",
        name: "GBP",
        showInLegend: true,
        xValueFormatString: "MMM YYYY",
        yValueFormatString: "₹#,##0.##",
        dataPoints: [
          { x: new Date("2017- 01- 01"), y: 84.927 },
          { x: new Date("2017- 02- 01"), y: 82.609 },
          { x: new Date("2017- 03- 01"), y: 81.428 },
          { x: new Date("2017- 04- 01"), y: 83.259 },
          { x: new Date("2017- 05- 01"), y: 83.153 },
          { x: new Date("2017- 06- 01"), y: 84.18 },
          { x: new Date("2017- 07- 01"), y: 84.84 },
          { x: new Date("2017- 08- 01"), y: 82.671 },
          { x: new Date("2017- 09- 01"), y: 87.496 },
          { x: new Date("2017- 10- 01"), y: 86.007 },
          { x: new Date("2017- 11- 01"), y: 87.233 },
          { x: new Date("2017- 12- 01"), y: 86.276 },
        ],
      },
      // {
      //   type: "area",
      //   name: "USD",
      //   showInLegend: true,
      //   xValueFormatString: "MMM YYYY",
      //   yValueFormatString: "₹#,##0.##",
      //   dataPoints: [
      //     { x: new Date("2017- 01- 01"), y: 67.515 },
      //     { x: new Date("2017- 02- 01"), y: 66.725 },
      //     { x: new Date("2017- 03- 01"), y: 64.86 },
      //     { x: new Date("2017- 04- 01"), y: 64.29 },
      //     { x: new Date("2017- 05- 01"), y: 64.51 },
      //     { x: new Date("2017- 06- 01"), y: 64.62 },
      //     { x: new Date("2017- 07- 01"), y: 64.2 },
      //     { x: new Date("2017- 08- 01"), y: 63.935 },
      //     { x: new Date("2017- 09- 01"), y: 65.31 },
      //     { x: new Date("2017- 10- 01"), y: 64.75 },
      //     { x: new Date("2017- 11- 01"), y: 64.49 },
      //     { x: new Date("2017- 12- 01"), y: 63.84 },
      //   ],
      // },
    ],
  };
  return (
    <div className="p-5">
      {/* <div className="mt-">
        <h2 className="text-2xl font-bold text-blue-600">Chart area Year</h2>
        <CanvasJSChart options={options} />
      </div> */}
      <div className="mt-[30px]">
        <h2 className="text-2xl font-bold text-blue-600">
          Chart area Year month day
        </h2>
        <CanvasJSChart options={optionsYMD} />
      </div>
      {/* <div className="mt-[30px]">
        <h2 className="text-2xl font-bold text-blue-600">Chart column Year</h2>
        <CanvasJSChart options={optionsColumn} />
      </div> */}
    </div>
  );
};

export default BarChart;
