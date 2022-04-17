import { v4 } from 'uuid'
// Base url
export const BASE_URL = 'https://localhost:5001';
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
        text: 'Low level'
    },
    {
        id: v4(),
        value: 2,
        text: 'Medium level'
    },
    {
        id: v4(),
        value: 3,
        text: 'High level'
    },
]