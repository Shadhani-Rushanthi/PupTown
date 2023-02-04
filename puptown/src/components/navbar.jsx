import React from 'react'
import styled from 'styled-components'
import '../index.scss'
import logo from '../images/logo.svg'

const NavBarContainer = styled.div`
  width: 100%;
  text-align:center;
  height: 85px;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
  margin:0;
  padding: 5px 20px;
  box-sizing: border-box;
  box-shadow: 2px 2px 8px 5px rgba(0, 0, 0, 0.1);
`

const LeftContainer = styled.div`
  width: 20%;
  height: 100%;
  border: 1px solid black;
`

const Logo = styled.img`
  width:100%;
`

const RightContainer = styled.div`
  height: 100%;
  width: 80%;
  border: 1px solid black;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
`

const SignInItems = styled.ul`
  width: 100%;
  heigh: 100%;

`

const SignOutItems = styled.ul`
  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content: space-between;
`

const Item = styled.li`

`


const Navbar = () => {
  return (
    <>
      <NavBarContainer>
        <LeftContainer>
          <Logo src={logo}/>
        </LeftContainer>

        <RightContainer>
          <SignInItems>
            <Item href="./"></Item>
            <Item href="./landing"></Item>
            <Item href="./profile"></Item>
          </SignInItems>
          <SignOutItems>
            hi hi right
          </SignOutItems>
        </RightContainer>
      </NavBarContainer>
    </>
  )
}

// const Container = styled.div`
//   box-sizing: border-box;
//   max-width: 100vw;
//   min-height: 92px;
//   // background-color: $Maroon;

export default Navbar