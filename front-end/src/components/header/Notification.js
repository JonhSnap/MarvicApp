import React, { useEffect, useState } from 'react'
import useTooltip from '../../hooks/useTooltip';
import Tooltip from '../tooltip/Tooltip';
import useModal from '../../hooks/useModal'
import NotificationBoard from '../selectbox/NotificationBoard';
import { BASE_URL, documentHeight } from "../../util/constants";
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import axios from 'axios';

const secondThirdScreen = (documentHeight * 2) / 3;

function Notification() {
  const { isHover, coord, nodeRef } = useTooltip();
  const [coordNotify, setCoorNotify] = useState({});
  const [show, setShow, handleClose] = useModal();
  const [notifyData, setNotifyData] = useState({})
  // handle click
  const handleClick = () => {
    const bounding = nodeRef.current.getBoundingClientRect();
    if (bounding) {
      console.log(bounding);
      setCoorNotify(bounding);
      setShow(true);
    }
  }
  const loadNotification = async () => {
    const resp = await axios.get(`${BASE_URL}/api/Notifications/Get`);
    if (resp.status === 200) {
      setNotifyData(resp.data);
    }
  }
  // create connection
  const connection = new HubConnectionBuilder()
    .withUrl('https://localhost:5001/hubs/marvic')
    .configureLogging(LogLevel.Information)
    .build();
  useEffect(() => {
    loadNotification();
    connection
      .start()
      .then((res) => {
        connection.on("Issue", () => {
          loadNotification();
        });
      })
      .catch((e) => console.log("Connecttion faild", e));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <>
      {
        show &&
        <NotificationBoard
          bodyStyle={{
            top: coordNotify.bottom <= secondThirdScreen ? coordNotify.bottom + 10 : null,
            right: window.innerWidth - coordNotify.right,
            bottom:
              coordNotify.bottom > secondThirdScreen
                ? documentHeight - coordNotify.top
                : null,
          }}
          onClose={handleClose}
          notifyData={notifyData}
        />
      }
      {
        isHover &&
        <Tooltip coord={coord}>Notifications</Tooltip>
      }
      <div onClick={handleClick} ref={nodeRef} className="notifications header-right-option">
        <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" viewBox="0 0 20 20" fill="currentColor">
          <path d="M10 2a6 6 0 00-6 6v3.586l-.707.707A1 1 0 004 14h12a1 1 0 00.707-1.707L16 11.586V8a6 6 0 00-6-6zM10 18a3 3 0 01-3-3h6a3 3 0 01-3 3z" />
        </svg>
        {
          Object.entries(notifyData).length > 0 &&
          notifyData?.countUnView > 0 &&
          <span className="notify-count">{notifyData?.countUnView}</span>
        }
      </div>
    </>
  )
}

export default Notification