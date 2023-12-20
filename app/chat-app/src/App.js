import { Box } from '@mui/material';
import './App.css';
import MemberList from './chat/member';
import Memsage from './chat/memsage';

function App() {
  return (
    <Box sx={{ with : '100%', display : 'flex'}}>
      <MemberList/>
      <Memsage/>
    </Box>
  );
}

export default App;
