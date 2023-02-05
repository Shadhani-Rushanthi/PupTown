import React from 'react'
import styled from 'styled-components'
import '../index.scss'
import logo from '../images/logo.svg'
import dog from '../images/dog.svg'
import notification from '../images/notification.png'

const NavBarContainer = styled.div`
  width: 100%;
  text-align:center;
  height: 85px;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
  margin:0;
  padding: 5px 10%;
  box-sizing: border-box;
  box-shadow: 2px 2px 8px 5px rgba(0, 0, 0, 0.1);
`

const LeftContainer = styled.div`
  width: 20%;
  height: 100%;
  // border: 1px solid black;
`

const Logo = styled.img`
  width:100%;
`

const RightContainer = styled.div`
  height: 100%;
  width: 80%;
  // border: 1px solid black;
  display:flex;
  flex-direction: row;
  justify-content: flex-end;
  align-items: center;
`

const SignInItems = styled.div`
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
`

const SignOutItems = styled.div`
  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content: space-between;
`

const Box = styled.div`
border-left: 2px solid #D9183B;
`

const Item = styled.a`
  padding: 5px 20px;  
  color: #D9183B;
  font-weight:500;

`
const ProfileLogo = styled.img`
  margin: 5px 20px 5px 30px; 
  height: 40px;
  width: 40px;
  border-radius: 20px;  
`

const Navbar = () => {
  var logged = true;

  const logOut = () => {
    logged = false;
  }

  return (
    <>
      <NavBarContainer>
        <LeftContainer>
          <Logo src={logo}/>
        </LeftContainer>

        <RightContainer>
          {
            logged ? 
            <>
              <SignOutItems>
                <Item href='./Home'>Home</Item>
                <Item href='./profile'>Communities</Item>
                <Item href='./Home'>Messages</Item>
                <Item href='./Home'>Find Your Match</Item>
                <Item href='./profile'>Profile</Item>
                <Item href='./Home'>
                  <Logo src={notification}/>
                </Item>
                <ProfileLogo src={dog} onClick={logOut}/>
              </SignOutItems>
            </>
            : 
            <>
              <SignInItems>
                <Item href='./'>About</Item>
                <Item href='./home'>Help</Item>
                <Box>
                  <Item href='./signIn'>SignIn</Item>
                  <Item  href='./signUp' className='signUp'>SignUp</Item>
                </Box>
              </SignInItems>
            </>
          }


        </RightContainer>
      </NavBarContainer>
    </>
  )
}

export default Navbar