import { v4 } from 'uuid'
// Base url
export const BASE_URL = 'https://localhost:5001';
// key current project
export const  KEY_CURRENT_PROJECT = 'key_current_project';
// Levels
export const levels = [
    {
        id: v4(),
        value: 0,
        text: 'Choose an access level'
    },
    {
        id: v4(),
        value: 1,
        text: 'Public'
    },
    {
        id: v4(),
        value: 2,
        text: 'Limited'
    },
    {
        id: v4(),
        value: 3,
        text: 'Private'
    },
]
export const issueTypes = [
    {
        id: 1,
        value: 1,
        title: 'story'
    },
    {
        id: 2,
        value: 2,
        title: 'stask'
    },
    {
        id: 3,
        value: 3,
        title: 'bug'
    },
]