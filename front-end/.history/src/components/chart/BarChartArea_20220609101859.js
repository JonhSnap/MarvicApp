import React, { useEffect, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
const BarChartArea = () => {
  const [datapoint, setDatapoint] = useState([]);
  var dataPoints = [];

  const dataP = async () => {
    await axios
      .get("https://canvasjs.com/data/gallery/react/nifty-stock-price.json")
      .then((res) => {
        setDatapoint(res.data);
      });
  };
  useEffect(() => {
    dataP();
  }, []);

  if (datapoint && datapoint.length > 0) {
    for (var i = 0; i < datapoint.length; i++) {
      dataPoints.push({
        x: new Date(datapoint[i].x),
        y: datapoint[i].y,
      });
    }
  }
  console.log("dataPoints", dataPoints);

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
        dataPoints: dataPoints,
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

export default BarChartArea;
