import React from 'react'
import $ from 'jquery';
import Select from 'react-select'

export default function DropDownComponent() {
    const options = [
        { value: '0', label: <div><img src={'https://marvic-5.atlassian.net/rest/api/2/universal_avatar/view/type/issuetype/avatar/10315?size=medium'} height="20px" width="20px"/></div> },
        { value: '1', label: <div><img src={'https://marvic-5.atlassian.net/rest/api/2/universal_avatar/view/type/issuetype/avatar/10315?size=medium'} height="20px" width="20px"/></div> },
        { value: '2', label: <div><img src={'https://marvic-5.atlassian.net/rest/api/2/universal_avatar/view/type/issuetype/avatar/10315?size=medium'} height="20px" width="20px"/></div> }
    ]

    return (
        <>
            <Select options={options} 
            defaultValue={{ value: '0', label: <div><img src={'https://marvic-5.atlassian.net/rest/api/2/universal_avatar/view/type/issuetype/avatar/10315?size=medium'} height="20px" width="20px"/></div>  }}/>
        </>
    )
}
