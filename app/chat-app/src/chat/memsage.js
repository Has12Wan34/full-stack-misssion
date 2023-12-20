import React from 'react';
import { Box, Card, TextField } from '@mui/material';

export default function Messages() {
    const [name, setName] = React.useState('Cat in the Hat');
    return (
        <Box sx={{ width: '70%' }}>
            <Box sx={{ background: '#F8F8FF', height: '700px', padding: '0px 10px 10px 10px' }}>
                <Box sx={{ paddingTop: '10px' }}>
                    <Card sx={{ padding: '10px', width: '20%' }}>kpl</Card>
                </Box>
            </Box>
            <TextField
                value={name}
                sx={{ width: '100%' }}
                onChange={(event) => {
                    setName(event.target.value);
                }}
            />
        </Box>

    );
}