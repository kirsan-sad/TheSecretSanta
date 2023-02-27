import { createSlice } from '@reduxjs/toolkit';

const serchTermSlice = createSlice({
  name: 'serchTerm',
  initialState: {
    searchQuery: '',
  },
  reducers: {
    setSearchQuery: (state, action) => {
      state.searchQuery = action.payload;
    },
  },
});

export const { setSearchQuery } = serchTermSlice.actions;
export default serchTermSlice.reducer;