import React from 'react'
import styled from 'styled-components'
import '../index.scss'

const Container = styled.div`
    width: 40%;
    margin: 80px auto;
    border-radius: 10px;
    border: 1px solid #c2bebe;
    padding: 40px;
    display:flex;
    flex-direction: column;
    justify-content:center;
    align-items: center;
`

const Login = styled.div`
    width:100%;
`

const Button = styled.button`
  padding: 10px;
  width: 100%;
  border-radius: 20px;
  font-weight: 500;
  letter-spacing: 2px;
  cursor: pointer;
  margin: 8px 0px;
`

const Seperator = styled.div`
    width: 100%;
    margin: 8px 0px;
    position:relative;
`

const Form = styled.form`
    width: 100%;
    display:flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
`

const Input = styled.input`
    width: 100%;
    margin: 8px 160px;
    border-radius: 5px;
    padding: 8px 6px;
    border :1px solid grey;
`

const Submit = styled.div`
    width:100%;
    margin:10px;
`

const Condition = styled.p`
    color: #747474;
    width:100%;
`

const ChekBox = styled.input`
    background-color: #8C030E;
`
const Submitbtn = styled.button`
  padding: 10px;
  width: 100%;
  border-radius: 10px;
  font-weight: 500;
  letter-spacing: 2px;
  cursor: pointer;
  border: none;
  color:white;
  background-color: #8C030E;
`

const SignUp = () => {
  return (
    <>
        <Container>
            <h1>Join the PupTown</h1>
            <Login>
                <Button className='google'>Continue with Google</Button>
                <Button className='apple'>Continue with Apple</Button>
            </Login>
            <Seperator>
                <hr/>
            </Seperator>
            <Form>
                <Input type="text" id="uname" name="uname" placeholder="User Name" required />
                <Input type="password" id="pwd" name="pwd" placeholder="Password" required />
                <Submit>
                    <Condition>
                        <ChekBox type="checkbox" id="altemai" name="altemai" placeholder="Alternative Email" required /> Forgot password
                    </Condition>
                    <Submitbtn>Sign In</Submitbtn>
                </Submit>
            </Form>
        </Container>
    </>
  )
}

export default SignUp