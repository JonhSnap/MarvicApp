import React, { useEffect, useState } from 'react'
import '../scss/TestResults.scss'
import axios from 'axios'
import { BASE_URL } from '../util/constants'
import { Link } from 'react-router-dom'

import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { v4 } from 'uuid';

function ViewTestPage() {
    const [listTest, setListTest] = useState([]);

    useEffect(() => {
        const getListTest = async () => {
            const resp = await axios.get(`${BASE_URL}/api/TestResults/GetTestResult`);
            if (resp && resp.status === 200) {
                setListTest(resp.data);
            }
        }
        getListTest();
    }, [])
    useEffect(() => {
        document.title = 'Marvic - Test results'
    }, [])

    return (
        <div className='container results-wrapper have-y-scroll'>
            <div className="wrapper">
                <Typography variant='h3' style={{ marginBottom: 20, color: '#0052cc' }}>Test resutls</Typography>
                <Link to='/testlist' className='test-link'>Go to test</Link>
            </div>
            {
                listTest.length > 0 &&
                listTest.map((item, index) => (
                    <Accordion key={v4()}>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls={index}
                            id={index}
                        >
                            <Typography>{item.testName}</Typography>
                        </AccordionSummary>
                        {
                            item.items.map((testItem, index) => (
                                <AccordionDetails key={v4()}>
                                    <div className='test-detail'>
                                        <span className='stt'>{index + 1}.</span>
                                        <div className='wrapper-score'><span>Score:</span><span>{testItem.score}</span></div>
                                        <span className='date'>{testItem.createDate}</span>
                                    </div>
                                </AccordionDetails>
                            ))
                        }
                    </Accordion>
                ))
            }
        </div>
    )
}

export default ViewTestPage