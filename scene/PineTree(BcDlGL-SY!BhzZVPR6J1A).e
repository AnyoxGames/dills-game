13
3384434229249
404866269705368 1761863289910369600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -13.8689947128295898,
    "Y": 9.4716157913208008
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404864195409122:1761863289427056600",
  "next_sibling": "404868344150154:1761863290393717900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404866269954166:1761863289910427000",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404866270087724:1761863289910458200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404866269954166:1761863289910427000",
    "DefaultRenderer": "404866270140012:1761863289910470300",
    "DepletedRenderer": "404866270122726:1761863289910466400"
  }
},
{
  "cid": 5,
  "aoid": "404866270101527:1761863289910461400",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
