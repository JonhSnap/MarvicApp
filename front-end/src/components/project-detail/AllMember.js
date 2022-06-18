import React from 'react'
import { Avatar, AvatarGroup, IconButton, Menu, MenuItem } from '@mui/material'
import DeleteIcon from '@mui/icons-material/Delete';
import Tippy from '@tippyjs/react'
import { v4 } from 'uuid';

function stringToColor(string) {
    let hash = 0;
    let i;

    /* eslint-disable no-bitwise */
    if (string) {
        for (i = 0; i < string.length; i += 1) {
            hash = string.charCodeAt(i) + ((hash << 5) - hash);
        }
    }

    let color = '#';

    for (i = 0; i < 3; i += 1) {
        const value = (hash >> (i * 8)) & 0xff;
        color += `00${value.toString(16)}`.slice(-2);
    }
    /* eslint-enable no-bitwise */

    return color;
}
function stringAvatar(name) {
    return {
        sx: {
            bgcolor: stringToColor(name),
        },
        children: `${name?.split(' ')[0][0]}${name?.split(' ')[1][0]}`,
    };
}
function AllMember({ members, handleDeleteMember }) {
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };
    return (
        <>
            <AvatarGroup style={{ cursor: "pointer" }} onClick={handleClick} max={3}>
                {
                    members?.length > 0 &&
                    members.map(item => (
                        <Tippy key={v4()} content={item.fullName}>
                            {
                                item.avatar_Path ?
                                    <Avatar alt="Remy Sharp" src={item.avatar_Path} /> :
                                    <Avatar {...stringAvatar(item.fullName)} />
                            }
                        </Tippy>
                    ))
                }
            </AvatarGroup>
            <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                    'aria-labelledby': 'basic-button',
                }}
            >
                <div className='max-h-[250px] overflow-auto have-y-scroll'>
                    {
                        members?.length > 0 &&
                        members.map(item => (
                            <MenuItem
                                key={v4()}
                                style={{ backgroundColor: 'white' }}
                            >
                                <div className='flex items-center min-w-[230px]'>
                                    {
                                        item.avatar_Path ?
                                            <Avatar style={{ width: 25, height: 25, fontSize: 12 }} alt="Remy Sharp" src={item.avatar_Path} /> :
                                            <Avatar style={{ width: 25, height: 25, fontSize: 12 }} {...stringAvatar(item.fullName)} />
                                    }
                                    <div className='ml-3 flex flex-col justify-between'>
                                        <span className='text-[12px] font-semibold'>{item.fullName}</span>
                                        <span className='text-[12px] opacity-80 text-gray-500'>{item.userName}</span>
                                    </div>
                                    <Tippy content='Delete'>
                                        <IconButton onClick={() => handleDeleteMember(item.id)} style={{ marginLeft: 'auto', padding: 0 }} aria-label="delete">
                                            <DeleteIcon />
                                        </IconButton>
                                    </Tippy>
                                </div>
                            </MenuItem>
                        ))
                    }
                </div>
            </Menu>
        </>
    )
}

export default AllMember