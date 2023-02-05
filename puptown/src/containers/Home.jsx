import React from 'react'
import styled from 'styled-components'
import Post from '../components/postCard'

const Container = styled.div`
  width: 100%;
  display:flex;
  flex-direction: row;
  justify-content:center;
  align-items: center;
  margin:0px;
  padding:40px 50px;
  box-sizing: border-box;
  min-height:100vh;
`

const ProfileSection = styled.div`
  width:20%;
  min-height: 100vh;
  padding:20px;
  // background-color: green;
  border-right: 3px solid #D9183B;
`

const PostSection = styled.div`
  // background-color: blue;
  min-height: 100vh;
  width:60%;
`

const AddSection = styled.div`
  // background-color: red;
  padding:20px;
  min-height: 100vh;
  border-left: 3px solid #D9183B;
  width:20%;
`
const Home = () => {
  return (
    <>
      <Container>
        <ProfileSection>
    sention
        </ProfileSection>
        <PostSection>
          <Post/>
        </PostSection>
        <AddSection>
          sention
        </AddSection>
      </Container>
    </>
  )
}

export default Home