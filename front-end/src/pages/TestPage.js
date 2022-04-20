import React, { useState } from 'react'
import ConfirmComponent from '../components/confirm/ConfirmComponent'
import ScoreComponent from '../components/score/ScoreComponent'
import '../scss/TestPage.scss'

export default function TestPage() {
    const [showConfirm, setShowConfirm] = useState(false)
    const [showScore, setShowScore] = useState(false)

    const showComponentConfirm = (childData) => {
        setShowConfirm(childData)
    }

    const showComponentScore = (childData) => {
        setShowScore(childData)
    }

    return (
        <div>
            <div className='wrap'>
                <div id="test">
                    <div className="test-title">
                        <div className="title">
                            Tiêu đề bài kiểm tra
                        </div>
                        <div className="num-test">
                            Số lượng câu hỏi
                        </div>
                    </div>
                    <div className="test-content">
                        <div className="question">
                            <div className="block-blue"></div>
                            Câu hỏi 1
                        </div>
                        <div className="wrap-answer">
                            <div className="child-answer">
                                <input type="radio" name="answer" className="answer" id="answer1" /> <label htmlFor="answer1">Đáp án 1</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer" className="answer" id="answer2" /> <label htmlFor="answer2">Đáp án 2</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer" className="answer" id="answer3" /> <label htmlFor="answer3">Đáp án 3</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer" className="answer" id="answer4" /> <label htmlFor="answer4">Đáp án 4</label>
                            </div>
                        </div>
                    </div>
                    <div className="test-content">
                        <div className="question">
                            <div className="block-blue"></div>
                            Câu hỏi 1
                        </div>
                        <div className="wrap-answer">
                            <div className="child-answer">
                                <input type="radio" name="answer1" className="answer" id="answer1-1" /> <label htmlFor="answer1-1">Đáp án 1</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer1" className="answer" id="answer1-2" /> <label htmlFor="answer1-2">Đáp án 2</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer1" className="answer" id="answer1-3" /> <label htmlFor="answer1-3">Đáp án 3</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer1" className="answer" id="answer1-4" /> <label htmlFor="answer1-4">Đáp án 4</label>
                            </div>
                        </div>
                    </div>
                    <div className="test-content">
                        <div className="question">
                            <div className="block-blue"></div>
                            Câu hỏi 2
                        </div>
                        <div className="wrap-answer">
                            <div className="child-answer">
                                <input type="radio" name="answer2" className="answer" id="answer2-1" /> <label htmlFor="answer2-1">Đáp án 1</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer2" className="answer" id="answer2-2" /> <label htmlFor="answer2-2">Đáp án 2</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer2" className="answer" id="answer2-3" /> <label htmlFor="answer2-3">Đáp án 3</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer2" className="answer" id="answer2-4" /> <label htmlFor="answer2-4">Đáp án 4</label>
                            </div>
                        </div>
                    </div>
                    <div className="test-content">
                        <div className="question">
                            <div className="block-blue"></div>
                            Câu hỏi 3
                        </div>
                        <div className="wrap-answer">
                            <div className="child-answer">
                                <input type="radio" name="answer3" className="answer" id="answer3-1" /> <label htmlFor="answer3-1">Đáp án 1</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer3" className="answer" id="answer3-2" /> <label htmlFor="answer3-2">Đáp án 2</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer3" className="answer" id="answer3-3" /> <label htmlFor="answer3-3">Đáp án 3</label>
                            </div>
                            <div className="child-answer">
                                <input type="radio" name="answer3" className="answer" id="answer3-4" /> <label htmlFor="answer3-4">Đáp án 4</label>
                            </div>
                        </div>
                    </div>
                    <button className="submit-btn" onClick={() => showComponentConfirm(true)}>Submit</button>
                </div>
            </div>
            {showConfirm && <ConfirmComponent showConfirm={showComponentConfirm} showScore = {showComponentScore}/>}
            {showScore && <ScoreComponent showScore = {showComponentScore}/>}
        </div>
    )
}