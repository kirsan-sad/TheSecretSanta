import React, { useEffect } from 'react';
import { useSelector } from 'react-redux';
import Header from '../../components/Header';
import WishList from '../../components/WishList';

import { useSearchWishQuery } from '../../services/wishApi';

const HomePage = () => {
  const searchQuery = useSelector((state) => state.setSearchQuery.searchQuery);
  const { data: wishList, isError, isLoading } = useSearchWishQuery(searchQuery);

  isError && console.log(isError);
  
  return (
    <> 
      <div className="shadow-md bg-white">
        <Header/>
      </div>

      {wishList && <WishList wishes={wishList} isLoading={isLoading}/>}
    </>
  )
}

export default HomePage