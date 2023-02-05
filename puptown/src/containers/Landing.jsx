import React from 'react'
import styled from 'styled-components'
import heroImg from '../images/Herosection.svg'
import SecondImage from '../images/landingSecond.svg'
import Brands from '../images/Brandsection.svg'
import footer from '../images/Footer.svg'

const Container = styled.div`
  width: 100%;
  display:flex;
  flex-direction: column;
  justify-content:center;
  align-items: center;
  margin:0;
  padding:0;
  box-sizing: border-box;
  min-height:100vh;
`

const HeroSection = styled.img`
  // width: 100%;
`

const SecondSection = styled.div`
  width:100%;
  height: 80vh;
  background-color: #F2B28D;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
`

const Left = styled.div`
  width:50%;
  // margin: 10px 0 10px 10%;
  margin-left: 10%;
  h1{
    font-size: 45px;
  }
`
const Right = styled.div`
  width:50%;
  margin-right: 10%;
  // margin: 10px 10%;
`
const Button = styled.button`
  padding: 30px 120px;
  background-color: #8C030E;
  border: none;
  border-radius: 5px;
  color: White;
  font-size: 1.5rem;
  font-weight: 500;
  letter-spacing: 2px;
  cursor: pointer;
`
const SecondImg = styled.img`

`

const BrandSection = styled.img`
  width:100%;
`

const Landing = () => {
  return (
    <>
      <Container>
        <HeroSection src={heroImg}/>
        <SecondSection>
          <Left>
            <h1>Join us in finding the best partner for your pups. Join the community for the betterment of man’s best friend</h1>
            <Button>Sign Up</Button>
          </Left>
          <Right>
            <SecondImg src={SecondImage}/>
          </Right>
        </SecondSection>
        <BrandSection src={Brands}/>
        <BrandSection src={footer}/>
      </Container>
    </>
  )
}

export default Landing