import React from 'react'
import styled from 'styled-components'
import dog from '../images/dog.svg'
import fav from '../images/fav.svg'
import star from '../images/start.svg'
import comment from '../images/comment.svg'
import chat from '../images/chat.svg'
import del from '../images/delete.svg'

const Container = styled.div`
  width: 600px;
  height:600px;
  display:flex;
  flex-direction: column;
  justify-content:space-between;
  // background-color:grey;
  align-items: center;
  margin:0 auto;
  padding:0;
  box-sizing: border-box;
`

const TopSection = styled.div`
  width: 100%;
  height: 520px;
  display:flex;
  flex-direction: column;
  // align-items:center;
  box-sizing: border-box;
  padding: 15px;
  box-shadow: 2px 2px 8px 5px rgba(0, 0, 0, 0.1);
`

const CommentSection = styled.div`
    width: 100%;
    height: 60px;
    display:flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    box-shadow: 2px 2px 8px 5px rgba(0, 0, 0, 0.1);
`
const Image = styled.img`
  width: 100%;
  // heigth: 550px !important;
  overflow: hidden;
`

const Name = styled.h3`
  width: 100%;
  heigth: 20px; 
  margin: 12px 0px 0px 0px;
  color: #414141;
`

const Caption = styled.p`
  width: 100%;
  margin: 8px 0px 0px 0px;
  color: #414141;
  heigth: 20px;
`

const Section = styled.button`
  width: 40px;
  height: 40px;
  border:none;
  background-color: white;
  cursor: pointer;
`

const Icon = styled.img`
  width: 100%;
  border: none;
  height: 100%;
`

const postCard = () => {
  return (
    <>
      <Container>
        <TopSection>
            <Image src={dog}/>
            <Name>Roxy</Name>
            <Caption>hi hi it's me</Caption>
        </TopSection>
        <CommentSection>
            <Section><Icon src={fav}/></Section>
            <Section><Icon src={star}/></Section>
            <Section><Icon src={comment}/></Section>
            <Section><Icon src={chat}/></Section>
            <Section><Icon src={del}/></Section>
        </CommentSection>
      </Container>
    </>
  )
}

export default postCard