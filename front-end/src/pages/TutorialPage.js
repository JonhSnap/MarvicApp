import React, { useState } from 'react'
import '../scss/Tutorial.scss'
import '../../src/index.scss'
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
// import { faAngleRight, faAngleLeft, faTimes } from '@fortawesome/free-solid-svg-icons'
import ShowImageComponent from '../components/show-image/ShowImageComponent'
import { data } from '../tutorial/data-tutorial'
import BtnNextPrevComponent from '../components/Next-Prev Button/BtnNextPrevComponent'
import { motion } from "framer-motion";

export default function Tutorial() {
    const [showImg, setShowImg] = useState(false)
    const [backGround, setBackGround] = useState()

    const [count, setCount] = useState(1)
    const [show, setShow] = useState(true)
    const [showAnimation, setShowAnimation] = useState(true)

    const clickImg = (boolean, backGround) => {
        setShowImg(boolean)
        setBackGround(backGround)
    }



    var imgContent = "calc(-50vw + 70px)"
    var textContent = "calc(50vw - 70px)"

    var initialImg = 0
    var initialContent = 0

    if (!showAnimation) {
        initialImg = imgContent;
        initialContent = textContent;
        textContent = 0;
        imgContent = 0;
    }

    const animationTextContent = {
        show: {
            left: textContent,
            opacity: 2
        },
        hidden: {
            left: initialContent,
            opacity: 0.1
        }
    }

    const animationImageContent = {
        show: {
            left: imgContent,
            opacity: 1
        },
        hidden: {
            left: initialImg,
            opacity: 0.1
        }
    }

    const animationImageLarge = {
        show: {
            x: 0,
            y: 0,
            opacity: 1
        },
        hidden: {
            x: Math.random() * 1000,
            y: Math.random() * 1000,
            opacity: 0.7
        }
    }

    const animationImageChild1 = {
        show: {
            x: 0,
            y: 0,
            opacity: 1
        },
        hidden: {
            x: Math.random() * 1000,
            y: Math.random() * 1000,
            opacity: 0.7
        }
    }

    const animationImageChild2 = {
        show: {
            x: 0,
            y: 0,
            opacity: 1
        },
        hidden: {
            x: Math.random() * 1000,
            y: Math.random() * 1000,
            opacity: 0.7
        }
    }

    const animationImageChild3 = {
        show: {
            x: 0,
            y: 0,
            opacity: 1
        },
        hidden: {
            x: Math.random() * 1000,
            y: Math.random() * 1000,
            opacity: 0.7
        }
    }

    const animationImageChild4 = {
        show: {
            x: 0,
            y: 0,
            z: 0,
            opacity: 1
        },
        hidden: {
            x: Math.random() * 1000,
            y: Math.random() * 1000,
            z: Math.random() * 1000,
            opacity: 0.7
        }
    }


    return (
        <>
            <div id='wrap-tutorial'>
                {
                    data.map((item) => {
                        var html
                        if (item.id == count) {
                            var booleanText
                            var booleanImg
                            (item.title2 != "") ? booleanText = true : booleanImg = true
                            html = <div id='main-tutorial'>
                                <motion.div className='content-tutorial'
                                    initial={false}
                                    variants={animationTextContent}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}
                                >
                                    <div className='title-content'>
                                        {item.title1}
                                    </div>
                                    <div className='content'>
                                        <p>Dựa trên phương pháp luận chuyển đổi số FPT Digital Kaizen, Chúng tôi cung cấp các dịch vụ tư vấn tùy chỉnh dựa trên chiến lược và định hướng phát triển, các đặc điểm và thế mạnh sẵn có của khách hàng, để phát triển và tăng trưởng, dưới dạng một lộ trình triển khai toàn diện và chi tiết. Tập trung vào hai lĩnh vực chính là Tư vấn chuyển đổi số cho doanh nghiệp và Tư vấn cho các tỉnh, thành phố.</p>
                                        <p>Trong lĩnh vực Tư vấn chuyển đổi số doanh nghiệp, Chúng tôi thiết kế lộ trình chuyển đổi số tùy chỉnh cho doanh nghiệp dựa trên những điều kiện nền tảng là hệ thống công nghệ thông tin và đội ngũ nhân lực số giúp doanh nghiệp Vận hành xuất sắc, Trải nghiệm khách hàng vượt trội, Mô hình kinh doanh đổi mới, Kích hoạt năng lực công nghệ, Xây dựng đội ngũ nhân lực số.</p>
                                        <p>Trong lĩnh vực Tư vấn cho các tỉnh thành, cùng các đối tác tư vấn chiến lược hàng đầu và các đối tác triển khai công nghệ, FPT cung cấp dịch vụ Tư vấn quy hoạch phát triển kinh tế xã hội và dịch vụ Tư vấn chuyển đổi số hướng tới sự phát triển nhảy vọt và bền vững.</p>
                                    </div>
                                </motion.div>
                                <motion.div className='image-tutorial'
                                    initial={false}
                                    variants={animationImageContent}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}
                                >
                                    {booleanText && <><div className='title-content'>
                                        {item.title2}
                                    </div><div className='content'>
                                            <p>Dựa trên phương pháp luận chuyển đổi số FPT Digital Kaizen, Chúng tôi cung cấp các dịch vụ tư vấn tùy chỉnh dựa trên chiến lược và định hướng phát triển, các đặc điểm và thế mạnh sẵn có của khách hàng, để phát triển và tăng trưởng, dưới dạng một lộ trình triển khai toàn diện và chi tiết. Tập trung vào hai lĩnh vực chính là Tư vấn chuyển đổi số cho doanh nghiệp và Tư vấn cho các tỉnh, thành phố.</p>
                                            <p>Trong lĩnh vực Tư vấn chuyển đổi số doanh nghiệp, Chúng tôi thiết kế lộ trình chuyển đổi số tùy chỉnh cho doanh nghiệp dựa trên những điều kiện nền tảng là hệ thống công nghệ thông tin và đội ngũ nhân lực số giúp doanh nghiệp Vận hành xuất sắc, Trải nghiệm khách hàng vượt trội, Mô hình kinh doanh đổi mới, Kích hoạt năng lực công nghệ, Xây dựng đội ngũ nhân lực số.</p>
                                            <p>Trong lĩnh vực Tư vấn cho các tỉnh thành, cùng các đối tác tư vấn chiến lược hàng đầu và các đối tác triển khai công nghệ, FPT cung cấp dịch vụ Tư vấn quy hoạch phát triển kinh tế xã hội và dịch vụ Tư vấn chuyển đổi số hướng tới sự phát triển nhảy vọt và bền vững.</p>
                                        </div></>}
                                    {booleanImg && <><motion.div  initial={false}
                                    variants={animationImageLarge}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}    whileHover={{scale: 1.03, boxShadow: "0px 0px 8px #000"}} className='image-large' style={{ backgroundImage: "url(" + item.imageLager + ")" }} onClick={() => clickImg(true, item.imageLager)}></motion.div>
                                        <motion.div initial={false}
                                    variants={animationImageChild1}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}  whileHover={{scale: 1.03, boxShadow: "0px 0px 8px #000"}} className='image-child-1' style={{ backgroundImage: "url(" + item.imageChild1 + ")" }} onClick={() => clickImg(true, item.imageChild1)}></motion.div>
                                        <motion.div  initial={false}
                                    variants={animationImageChild2}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}   whileHover={{scale: 1.03, boxShadow: "0px 0px 8px #000"}} className='image-child-2' style={{ backgroundImage: "url(" + item.imageChild2 + ")" }} onClick={() => clickImg(true, item.imageChild2)}></motion.div>
                                        <motion.div  initial={false}
                                    variants={animationImageChild3}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}   whileHover={{scale: 1.03, boxShadow: "0px 0px 8px #000"}} className='image-child-3' style={{ backgroundImage: "url(" + item.imageChild3 + ")" }} onClick={() => clickImg(true, item.imageChild3)}></motion.div>
                                        <motion.div  initial={false}
                                    variants={animationImageChild4}
                                    animate={show ? "show" : "hidden"}
                                    transition={{ type: 'spring', stiffness: 60 }}   whileHover={{scale: 1.03, boxShadow: "0px 0px 8px #000"}} className='image-child-4' style={{ backgroundImage: "url(" + item.imageChild4 + ")" }} onClick={() => clickImg(true, item.imageChild4)}></motion.div></>}
                                </motion.div>
                            </div>
                        }

                        return html
                    })
                }
                <BtnNextPrevComponent showAnimation={showAnimation} setShow={setShow} setShowAnimation={setShowAnimation} setCount={setCount} count={count} />
            </div>
            {showImg && <ShowImageComponent  backGround={backGround} clickImg={clickImg} showImg={showImg} />}
        </>
    )
}

