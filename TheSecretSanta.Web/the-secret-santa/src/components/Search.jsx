import React, { useState, useCallback } from 'react';
import { useDispatch } from 'react-redux';
import { debounce } from "lodash";
import { setSearchQuery } from "../store/redux/serchTermSlice";

const Search = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const dispatch = useDispatch();
    console.log("render Search");

  const updateSearchValue = useCallback(
    debounce((searchTerm) => {
      dispatch(setSearchQuery(searchTerm));
    }, 500),
    [],
  );

  const onChangeInput = (event) => {
    setSearchTerm(event.target.value);
    updateSearchValue(event.target.value);
  };

  const onClickClear = () => {
    dispatch(setSearchQuery(''));
    setSearchTerm('');
  };

  return (
    <div className="text-black pl-5 border border-gray-200 rounded-md hover:border-gray-300">
      <input
        type="text"
        id="wishlist-search"
        placeholder="Search..."
        value={searchTerm}
        onChange={onChangeInput}
      />
      {searchTerm && (
        <svg
        onClick={onClickClear}
        className="inline right-2.5 w-4 h-4 cursor-pointer fill-current text-gray-400 hover:text-gray-500"
        viewBox="0 0 20 20"
        xmlns="http://www.w3.org/2000/svg">
        <path d="M10 8.586L2.929 1.515 1.515 2.929 8.586 10l-7.071 7.071 1.414 1.414L10 11.414l7.071 7.071 1.414-1.414L11.414 10l7.071-7.071-1.414-1.414L10 8.586z" />
      </svg>
      )}
    </div>
  )
}

export default Search