import React, { useRef, useState } from 'react'
import MoreHorizIcon from '@mui/icons-material/MoreHoriz';
import { IconButton, Menu, MenuItem } from '@mui/material';
import { fetchIssue, updateIssues } from '../../reducers/listIssueReducer';
import createToast from '../../util/createToast';
import { useListIssueContext } from '../../contexts/listIssueContext';
import ModalDeleteIssue from './ModalDeleteIssue';

export default function OptionComponent({ project, issue, child = null }) {
    const [showConfirmDelete, setShowConfirmDelete] = useState(false);
    const [, dispatch] = useListIssueContext();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };
    // handle change flagg
    const handleChangeFlag = () => {
        const issueUpdate = { ...issue };
        if (issue.isFlagged) {
            issueUpdate.isFlagged = 0
        } else {
            issueUpdate.isFlagged = 1
        }
        updateIssues(issueUpdate, dispatch);
        createToast('success', issueUpdate.isFlagged ? 'Add flag successfully!' : 'Remove flag successfully!')
        setTimeout(() => {
            fetchIssue(project.id, dispatch);
        }, 500);
    }
    // handleDeleteIssue
    const handleDeleteIssue = async () => {
        setShowConfirmDelete(true)
    }

    return (
        <>
            <IconButton onClick={handleClick} style={{ padding: 0 }}>
                <MoreHorizIcon fontSize='medium' />
            </IconButton>
            <Menu
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
            >
                <MenuItem>
                    <div onClick={handleChangeFlag} role="button">
                        {issue?.isFlagged ? 'Remove flag' : 'Add flag'}
                    </div>
                </MenuItem>
                <MenuItem>
                    <div onClick={handleDeleteIssue} role="button">
                        Delete
                    </div>
                </MenuItem>
            </Menu>
            <ModalDeleteIssue project={project} issue={issue} dispatch={dispatch} open={showConfirmDelete} handleClose={() => setShowConfirmDelete(false)} />
        </>
    )
}
