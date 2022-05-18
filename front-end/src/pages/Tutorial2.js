import React from 'react';
import image from "../images/tutorial2/bg1.jpg";

function Tutorial2() {
    return (
        <>
        <div className="wrap-tutorial2 flex flex-col items-center w-[100vw] h-[100vh] overflow-y-auto">
            <div className="title-big w-fit h-fit mb-14">
                <span className="uppercase text-7xl font-bold">INSTRUCTION&nbsp;</span><span className="font-bold text-emerald-600 text-7xl">LAB</span>
                <div className="title-small w-full h-fit text-right uppercase text-4xl font-light">learn by reading</div>
            </div>
            <div className="red-text w-[35%] text-center text-4xl text-red-500 font-bold px-3 mb-14">
                Track 3: Explain the Impact of Commerce and Content Analytics on Marketing Automation.
            </div>
            <div className="content-child mb-8 w-[40%] h-fit text-2xl">One of the main benefits of bringing together commerce and content is the enhancement of marketing automation</div>
            <div className="content-child mb-8 w-[40%] h-fit text-2xl">Let's look at a series of event that might happen outside of a connected content and commerce environment:</div>
            <div className="content-text-image grid grid-cols-2 w-[40%] h-fit">
                <div className="bg-contain bg-no-repeat bg-center m-5" style={{ backgroundImage: "url(" + image + ")" }}>

                </div>
                <div className="content-text h-fit">
                    <p className="text-2xl mb-3">1. James researches refrigerator, trying to find the one that fits his home.</p>
                    <p className="text-2xl mb-3">2. Merchandising creates a special promotion for 10% off stove and microwave bundles because that was shown to be a popular combination in last month's data analysis</p>
                    <p className="text-2xl mb-3">1. James researches refrigerator, trying to find the one that fits his home.</p>
                    <p className="text-2xl mb-3">1. James researches refrigerator, trying to find the one that fits his home.</p>
                </div>
            </div>
            <div className="content-child mb-8 w-[40%] h-fit text-2xl">One of the main benefits of bringing together commerce and content is the enhancement of marketing automation</div>
            <div className="content-child mb-8 w-[40%] h-fit text-2xl">Let's look at a series of event that might happen outside of a connected content and commerce environment:</div>
        </div>
        </>
    );
}

export default Tutorial2;