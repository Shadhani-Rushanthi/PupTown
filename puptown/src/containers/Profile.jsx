import React from 'react'
import styled from 'styled-components'
import Post from '../components/postCard'
import dog from '../images/dog.svg'

const Container = styled.div`
  width: 80%;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: flex-start;
  margin:0 auto;
  padding:40px 50px;
  box-sizing: border-box;
  min-height:100vh;
`

const ProfileSection = styled.div`
  width:30%;
  padding: 50px;
  background-color: rgba(140, 3, 14, 0.267);
  display:flex;
  flex-direction: column;
  justify-content:center;
  align-items: center;
`

const MainDetails = styled.div`
  width: 100%;

`

const Details = styled.div`
  width: 100%;
`

const PostSection = styled.div`
  // background-color: blue;
  min-height: 100vh;
  width:70%;
`

const ProfileLogo = styled.img`
  margin: 0 auto; 
  // height: 40px;
  width: 100%;
  border-radius: 100%;  
`

const Name = styled.h1`
  width:100%;
  text-align: center;
`

const Detail = styled.div`
  width: 100%; 
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
`

const Type = styled.p`
  width: 40%;
  font-weight: 500;
`
const Value = styled.p`
  width: 60%;
  
`

const Profile = () => {
  return (
    <>
      <Container>
        <ProfileSection>
          <MainDetails>
           <ProfileLogo src={dog}/>
           <Name>Roxy</Name>
          </MainDetails>

          <Details>
            <Detail>
              <Type>Breed : </Type><Value>Pomenerian</Value>
            </Detail>
            <Detail>
              <Type>Age : </Type><Value>5 years</Value>
            </Detail>
            <Detail>
              <Type>Birthday : </Type><Value>40/05/2019</Value>
            </Detail>
            <Detail>
              <Type>Location : </Type><Value>Brooklyn, United States</Value>
            </Detail>
            <Detail>
              <Type>Origin : </Type><Value>Brooklyn, United States</Value>
            </Detail>
          </Details>
        </ProfileSection>
        <PostSection>
          <Post/>
        </PostSection>
      </Container>
    </>
  )
}

export default Profile