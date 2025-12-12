13
4587025072129
405043092932637 1761863331110365100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 15.9122943878173828,
    "Y": -10.6890077590942383
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405039802729544:1761863330343744200",
  "next_sibling": "405048457841184:1761863332360394300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405043093175845:1761863331110420700",
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
  "aoid": "405043093301405:1761863331110449900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405043093175845:1761863331110420700",
    "DefaultRenderer": "405043093354424:1761863331110462300",
    "DepletedRenderer": "405043093336794:1761863331110458300"
  }
},
{
  "cid": 5,
  "aoid": "405043093314778:1761863331110453100",
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
